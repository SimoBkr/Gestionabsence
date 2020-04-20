const gulp = require('gulp');
const concat = require('gulp-concat');
const sass = require('gulp-sass');
const notify = require('gulp-notify');

gulp.task('sass',function(){
    return gulp.src('/home/soufiane/Bureau/works/Projects/coreProject/wwwroot/scss/task/index.scss')
    .pipe(sass()).pipe(concat('index.css')).pipe(gulp.dest('/home/soufiane/Bureau/works/Projects/coreProject/wwwroot/dist/css'))
    .pipe(notify("convert success"));
})