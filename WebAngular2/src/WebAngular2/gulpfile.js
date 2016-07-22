"use strict";

var _ = require('lodash'),
    gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename');
var ts = require('gulp-typescript');;
var clean = require('gulp-clean');
var paths = {
  npm: './node_modules/',
  bower: './bower_components/',
  jsLib: './wwwroot/lib/js/',
  cssLib: './wwwroot/lib/css/',
  css: './wwwroot/css',
  font: './wwwroot/font'
};

var angularJs = [
    paths.npm + '@angular/common/bundles/common.umd.js',
    paths.npm + '@angular/core/bundles/core.umd.js',
    paths.npm + '@angular/forms/bundles/forms.umd.js',
    paths.npm + '@angular/http/bundles/http.umd.js',
    paths.npm + '@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
    paths.npm + '@angular/router/bundles/router.umd.js',
    paths.npm + '@angular/upgrade/bundles/upgrade.umd.js',
    paths.npm + '@angular/platform-browser/bundles/platform-browser.umd.js',
    paths.npm + '@angular/compiler/bundles/compiler.umd.js'
];

var js = [
    paths.npm + 'bootstrap/dist/js/bootstrap.js',
    paths.npm + 'systemjs/dist/system-polyfills.js',
    paths.npm + 'es6-shim/es6-shim.js',
    paths.npm + 'systemjs/dist/system.src.js',
    paths.npm + 'rxjs/bundles/Rx.js',
    paths.npm + 'typescript/lib/typescript.js',
    paths.npm + 'jquery/dist/jquery.js',
    paths.npm + 'reflect-metadata/Reflect.js',
    paths.npm + 'zone.js/dist/zone.js',

    paths.bower + 'jquery/dist/jquery.js',
    paths.bower + 'jquery-validation/dist/jquery.validate.js',
    paths.bower + 'jquery-validation-unobtrusive/jquery.validate.unobtrusive.js'

];

var styles = [
    paths.npm + 'bootstrap/dist/css/bootstrap.css',
    paths.npm + 'ng2-material/dist/ng2-material.css'
];

var fonts = [
    paths.npm + 'bootstrap/dist/fonts/*.*',
    paths.npm + 'ng2-material/dist/font.css'
];

gulp.task('copy-js', function () {
  _.forEach(js, function (file, _) {
    gulp.src(file)
        .pipe(gulp.dest(paths.jsLib))
  });
  _.forEach(angularJs, function (file, _) {
    gulp.src(file)
        .pipe(gulp.dest(paths.jsLib))
  });
});

gulp.task('copy-min-js', function () {
  _.forEach(js, function (file, _) {
    gulp.src(file)
        .pipe(uglify())
        .pipe(rename({ extname: '.min.js' }))
        .pipe(gulp.dest(paths.jsLib))
  });
  _.forEach(angularJs, function (file, _) {
    gulp.src(file)
        .pipe(uglify())
        .pipe(rename({ extname: '.min.js' }))
        .pipe(gulp.dest(paths.jsLib))
  });
});

gulp.task('copy-css', function () {
  _.forEach(styles, function (file, _) {
    gulp.src(file)
        .pipe(gulp.dest(paths.cssLib))
  });
  _.forEach(fonts, function (file, _) {
    gulp.src(file)
        .pipe(gulp.dest(paths.font))
  });
});

gulp.task('copy-min-css', function () {
  _.forEach(styles, function (file, _) {
    gulp.src(file)
        .pipe(cssmin())
        .pipe(rename({ extname: '.min.css' }))
        .pipe(gulp.dest(paths.cssLib))
  });
  _.forEach(fonts, function (file, _) {
    gulp.src(file)
        .pipe(gulp.dest(paths.font))
  });
});

//gulp.task('clean', function (callback) {
//  //del is an async function and not a gulp plugin (just standard nodejs)
//  //It returns a promise, so make sure you return that from this task function
//  //  so gulp knows when the delete is complete
//  return del([paths.jsLib, paths.cssLib, paths.style, paths.font]);
//});
//// Delete the dist directory
//gulp.task('clean', function () {
//  //, paths.cssLib, paths.style, paths.font
//  return gulp.src(paths.cssLib)
//      .pipe(clean());
//});

var tsProject = ts.createProject('./tsconfig.json');
gulp.task('ts', function () {
  var tsResult = gulp.src([
          "./wwwroot/script/*.ts",
          "./wwwroot/script/**/*.ts"
  ])
      .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
  return tsResult.js.pipe(gulp.dest('./wwwroot/script'));
});

gulp.task('copyJS', function () {
  gulp.src('./wwwroot/script/systemjsConfig.js')
      .pipe(gulp.dest('./wwwroot/script'));
});

gulp.task('watch.ts', ['ts'], function () {
  return gulp.watch(['./wwwroot/script/*.ts', './wwwroot/script/**/*.ts'], ['ts']);
});

gulp.task('watchJS', ['copyJS'], function () {
  return gulp.watch('./wwwroot/script/systemjsConfig.js', ['copyJS']);
});


gulp.task("angularScript", () => {
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


gulp.task('default', ['copy-js', 'copy-css', 'angularScript']);
gulp.task('minify', ['copy-min-js', 'copy-min-css']);
gulp.task('watch', ['watch.ts', 'watchJS']);