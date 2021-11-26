using System;

namespace DeeFlat.Homework.Services.Contracts
{
    public class HomeworkAccepted
    {
        public HomeworkAccepted(Guid courseId, Guid pupilId, Guid teacherId)
        {
            CourseId = courseId;
            PupilId = pupilId;
            TeacherId = teacherId;
        }

        public Guid CourseId { get; set; }
        public Guid PupilId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
