var gulp = require('gulp');
var del = require('del');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var cleanCss = require('gulp-clean-css');
var uncss = require('gulp-uncss');
var ts = require('gulp-typescript');
var tsProject = ts.createProject('tsconfig.json');

function clean() {
  return del([
    'temp/**'
  ]);
}

function styles() {
  return gulp.src(['./dev/app.scss'])
    .pipe(sass({ outputStyle: 'compressed' })
      .on('error', sass.logError))
    .pipe(cleanCss({ keepSpecialComments: 0 }))
    .pipe(uncss({
      html: [
        'http://localhost:12930/'
      ]
    }))
    .pipe(gulp.dest('Content/'));
}

function typescript() {
  return tsProject.src()
    .pipe(tsProject())
    .pipe(gulp.dest('temp'));
}

function libs() {
  return gulp.src([
    'bower_components/jquery/dist/jquery.min.js',
    'bower_components/foundation-sites/dist/plugins/foundation.core.js',
    'bower_components/foundation-sites/dist/plugins/foundation.responsiveToggle.js',
    'bower_components/foundation-sites/dist/plugins/foundation.util.mediaQuery.js',
    'bower_components/parallax.js/parallax.js'
  ])
      .pipe(concat('libs.js'))
      .pipe(uglify())
      .pipe(gulp.dest('temp/lib'));
}

function scripts() {
  return gulp.src([
  'temp/lib/libs.js',
  'dev/**/*.js'
  ], { base: './temp/' })
      .pipe(concat('app.js'))
      .pipe(uglify())
      .pipe(gulp.dest('content'));
}

function watch() {
  gulp.watch('./typescript/app.ts', gulp.series(typescript, scripts));
  gulp.watch('./dev/**/*.scss', styles);
}

gulp.task('public', gulp.series(clean, libs, typescript, scripts, styles, gulp.parallel(watch)));
