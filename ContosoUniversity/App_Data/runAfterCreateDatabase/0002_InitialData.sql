﻿SET IDENTITY_INSERT [dbo].[Instructor] ON 
GO
INSERT [dbo].[Instructor] ([ID], [LastName], [FirstName], [HireDate]) VALUES (1, N'Zheng', N'Roger', CAST(N'2004-02-12T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Instructor] ([ID], [LastName], [FirstName], [HireDate]) VALUES (2, N'Kapoor', N'Candace', CAST(N'2001-01-15T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Instructor] ([ID], [LastName], [FirstName], [HireDate]) VALUES (3, N'Harui', N'Roger', CAST(N'1998-07-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Instructor] ([ID], [LastName], [FirstName], [HireDate]) VALUES (4, N'Fakhouri', N'Fadi', CAST(N'2002-07-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Instructor] ([ID], [LastName], [FirstName], [HireDate]) VALUES (5, N'Abercrombie', N'Kim', CAST(N'1995-03-11T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Instructor] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (2, N'Economics', 100000.0000, CAST(N'2007-09-01T00:00:00.0000000' AS DateTime2), 2)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (3, N'Engineering', 350000.0000, CAST(N'2007-09-01T00:00:00.0000000' AS DateTime2), 3)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (4, N'Mathematics', 100000.0000, CAST(N'2007-09-01T00:00:00.0000000' AS DateTime2), 4)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (5, N'English', 350000.0000, CAST(N'2007-09-01T00:00:00.0000000' AS DateTime2), 5)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (1045, N'Calculus', 4, 4)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (1050, N'Chemistry', 3, 3)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (2021, N'Composition', 3, 5)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (2042, N'Literature', 4, 5)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (3141, N'Trigonometry', 4, 4)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (4022, N'Microeconomics', 3, 2)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (4041, N'Macroeconomics', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (1, N'Alexander', N'Carson', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (2, N'Alonso', N'Meredith', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (3, N'Anand', N'Arturo', CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (4, N'Barzdukas', N'Gytis', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (5, N'Li', N'Yan', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (6, N'Justice', N'Peggy', CAST(N'2017-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (7, N'Norman', N'Laura', CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Student] ([ID], [LastName], [FirstName], [EnrollmentDate]) VALUES (8, N'Olivetto', N'Nino', CAST(N'2011-09-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON 
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (1, 4022, 3, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (2, 1050, 3, NULL)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (3, 2021, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (4, 3141, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (5, 1045, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (6, 4041, 1, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (7, 4022, 1, 2)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (8, 1050, 1, 0)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (9, 1050, 4, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (10, 2021, 5, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (11, 2042, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (1, 4022)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (1, 4041)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (2, 1050)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (3, 1050)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (3, 3141)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (4, 1045)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (5, 2021)
GO
INSERT [dbo].[CourseAssignment] ([InstructorID], [CourseID]) VALUES (5, 2042)
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (2, N'Thompson 304')
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (3, N'Gowan 27')
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (4, N'Smith 17')
GO
