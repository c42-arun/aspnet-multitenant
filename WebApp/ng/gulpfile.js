var gulp = require('gulp');
var gutil = require('gulp-util');

gulp.task('default', function() {
    gutil.log('this is our first log entry');
});

gulp.task('secondlog', function() {
    gutil.log('this is our second log entry');
});