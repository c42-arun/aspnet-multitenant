var gulp = require('gulp');
var gutil = require('gulp-util');
var browserSync = require('browser-sync').create();

gulp.task('default', function() {
    browserSync.init({
        server: {
            baseDir: "./dist"
        }
    });
});

