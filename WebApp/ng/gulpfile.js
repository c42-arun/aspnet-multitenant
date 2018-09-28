var gulp = require('gulp');
var gutil = require('gulp-util');
var browserSync = require('browser-sync').create();
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var watchify = require('watchify');

gulp.task('scripts', function() {
    bundleAndBrowse(browserify('./svcc/main.js'));
});

gulp.task('watch', function() {
    var watcher = watchify(browserify('./svcc/main.js', watchify.args));

    // first run
    bundleAndBrowse(watcher); 
    browserSync.init({
        server: {
            baseDir: "./dist"
        }
    });    

    // subsequent runs on file change
    watcher.on('update', function() {
        bundleAndBrowse(watcher);
    });

    watcher.on('update', gutil.log);

});

gulp.task('default', function() {
    browserSync.init({
        server: {
            baseDir: "./dist"
        }
    });
});

function bundleAndBrowse(bundler) {
    return bundler
        .bundle()
        .on('error', function(e) {
            gutil.log(e);
        })
        .pipe(source('app.js'))
        .pipe(gulp.dest('./dist'))
        .pipe(browserSync.stream()); // automatically push to browserify
}

