// // File: /Data/SampleData.cs
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using System.Linq;

// namespace MyWebApp.Data
// {
//     public static class SampleData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//             using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
//             {
//                 try
//                 {
//                     if (context.Students.Any())
//                     {
//                         return;
//                     }

//                     var students = new Student[]
//                     {
//                         new Student { Fullname = "Nguyễn Văn A", Cohort = "Cohort 1", Classes = "Lớp A" },
//                         new Student { Fullname = "Trần Thị B", Cohort = "Cohort 2", Classes = "Lớp B" },
//                         new Student { Fullname = "Phạm Minh C", Cohort = "Cohort 3", Classes = "Lớp C" }
//                     };

//                     context.Students.AddRange(students);
//                     context.SaveChanges();
//                 }
//                 catch (Exception ex)
//                 {
//                     var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
//                     var logger = loggerFactory.CreateLogger("MyWebApp.Data.SampleData");
//                     logger.LogError(ex, "Error during data Initialize.");
//                     throw;
//                 }
//             }
//         }

//         public static void InitializeLearningResults(IServiceProvider serviceProvider)
//         {
//             using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
//             {
//                 try
//                 {
//                     if (context.LearningResults.Any())
//                     {
//                         return;   // Nếu đã có dữ liệu thì không thêm nữa
//                     }

//                     // Dữ liệu mẫu cho kết quả học tập
//                     var learningResults = new LearningResult[]
//                     {
//                         new LearningResult { StudentId = 4, SubjectName = "Toán", Semester = "Semester 1", Credits = 3, Score = 9.5M, Grade = "A"},
//                         new LearningResult { StudentId = 4, SubjectName = "Lý", Semester = "Semester 1", Credits = 3, Score = 8.0M, Grade = "B+" },
//                         new LearningResult { StudentId = 5, SubjectName = "Hóa", Semester = "Semester 2", Credits = 3, Score = 7.5M, Grade = "B" },
//                         new LearningResult { StudentId = 6, SubjectName = "Tin học", Semester = "Semester 3", Credits = 4, Score = 6.0M, Grade = "C" },
//                     };

//                     context.LearningResults.AddRange(learningResults);
//                     context.SaveChanges();
//                 }
//                 catch (Exception ex)
//                 {
//                     var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
//                     var logger = loggerFactory.CreateLogger("MyWebApp.Data.SampleData");
//                     logger.LogError(ex, "Error during data InitializeLearningResults.");
//                     throw;
//                 }
//             }
//         }
//     }
// }
