// import {
//   Injectable,
//   Optional
// } from '@angular/core';

// import { HttpClient } from '@angular/common/http';
// import { BehaviorSubject } from 'rxjs';
// import { SnackerService } from '../../services';
// import { ServerConfig } from '../../config';
// import { Course } from '../models';

// @Injectable()
// export class CourseService {
//   private course = new BehaviorSubject<Course>(null);
//   course$ = this.course.asObservable();

//   constructor(
//     private http: HttpClient,
//     private snacker: SnackerService,
//     @Optional() private config: ServerConfig
//   ) { }

//   getAllCourses = (): Promise<Course[]> => new Promise((resolve) => {
//     this.http.get<Course[]>(`${this.config.api}course/getAllCourses`)
//       .subscribe(
//         data => {
//           this.course.next(data);
//           resolve(data);
//         },
//         err => {
//           this.snacker.sendErrorMessage(err.error);
//           resolve(null);
//         }
//       );
//   })

//   getCourse = (id: number): Promise<Course> => new Promise((resolve) => {
//     this.http.get<Course>(`${this.config.api}course/getCourse/id`)
//       .subscribe(
//         data => {
//           this.course.next(data);
//           resolve(data);
//         },
//         err => {
//           this.snacker.sendErrorMessage(err.error);
//           resolve(null);
//         }
//       );
//   })

//   addCourse = (course: Course): Promise<boolean> => new Promise((resolve) => {
//     this.http.post(`${this.config.api}course/addCourse`, course)
//       .subscribe(
//         () => {
//           this.snacker.sendSuccessMessage(`${course.prop} successfully created`);
//           resolve(true);
//         },
//         err => {
//           this.snacker.sendErrorMessage(err.error);
//           resolve(false);
//         }
//       );
//   })

//   removeCourse = (course: Course): Promise<boolean> => new Promise((resolve) => {
//     this.http.post(`${this.config.api}course/removeCourse`, course)
//       .subscribe(
//         () => {
//           this.snacker.sendSuccessMessage(`${course.prop} successfully removed`);
//           resolve(true);
//         },
//         err => {
//           this.snacker.sendErrorMessage(err.error);
//           resolve(false);
//         }
//       );
//   })
// }
