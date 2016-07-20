var gulp = require('gulp');
var clean = require('gulp-clean');
var ts = require('gulp-typescript');;

var destPath = './wwwroot/lib/';

// Delete the dist directory
gulp.task('clean', function () {
  return gulp.src(destPath)
      .pipe(clean());
});

gulp.task("scriptsNStyles", () => {
  gulp.src([
          'es6-shim/es6-shim.min.js',
          'systemjs/dist/system-polyfills.js',
          'systemjs/dist/system.src.js',
          'reflect-metadata/Reflect.js',
          'rxjs/**',
          'zone.js/dist/**',
          '@angular/**',
          'jquery/dist/jquery.*js',
          'bootstrap/dist/js/bootstrap.*js'
  ], {
    cwd: "node_modules/**"
  })
      .pipe(gulp.dest("./wwwroot/lib"));

  gulp.src([
      'node_modules/bootstrap/dist/css/bootstrap.css'
  ]).pipe(gulp.dest('./wwwroot/lib/css'));
});

gulp.task('copyJS', function () {
  gulp.src('script/systemjsConfig.js')
      .pipe(gulp.dest('./wwwroot/script'));
});


var tsProject = ts.createProject('./tsconfig.json');
gulp.task('ts', function () {
  //var tsResult = tsProject.src()
  var tsResult = gulp.src([
          "script/*.ts",
          "script/**/*.ts"
  ])
      .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
  return tsResult.js.pipe(gulp.dest('./wwwroot/script'));
});

gulp.task('watch', ['watch.ts', 'watchJS']);

gulp.task('watch.ts', ['ts'], function () {
  return gulp.watch(['script/*.ts', 'script/**/*.ts'], ['ts']);
});

gulp.task('watchJS', ['copyJS'], function () {
  return gulp.watch('script/systemjsConfig.js', ['copyJS']);
});

gulp.task('default', ['scriptsNStyles', 'watch']);

//var gulp = require('gulp');

//gulp.task('thirdparty', function () {
//  gulp.src('./node_modules/core-js/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/core-js'));
//  gulp.src('./node_modules/@angular/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/@angular'));
//  gulp.src('./node_modules/zone.js/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/zone.js'));
//  gulp.src('./node_modules/systemjs/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/systemjs'));
//  gulp.src('./node_modules/reflect-metadata/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/reflect-metadata'));
//  gulp.src('./node_modules/rxjs/**/*.js')
//      .pipe(gulp.dest('./wwwroot/node_modules/rxjs'));

//});

//gulp.task('copy', function () {
//  gulp.src('./app/**/*.*')
//      .pipe(gulp.dest('./wwwroot/app'));
//});

//gulp.task('watch', function () {
//  gulp.watch('./app/**/*.*', ['copy']);
//});

//gulp.task('default', ['thirdparty', 'copy', 'watch']);
