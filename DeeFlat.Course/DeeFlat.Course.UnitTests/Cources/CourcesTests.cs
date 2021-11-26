using AutoFixture;
using AutoFixture.AutoMoq;
using DeeFlat.Abstractions.Exceptions;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.Course.Core.Domain.Enums;
using DeeFlat.Course.Services.Courses.AddCourse;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DBCource = DeeFlat.Course.Core.Domain.Course;


namespace DeeFlat.Course.UnitTests.Cources
{
    public class CourcesTests
    {
        private AddCourseCommandHandler _addHandler;
        private Mock<IRepository<DBCource>> _courceRepository;
        public CourcesTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _courceRepository = fixture.Freeze<Mock<IRepository<DBCource>>>();
            _addHandler = fixture.Build<AddCourseCommandHandler>().OmitAutoProperties().Create();
        }

        [Fact]
        public async Task AddCourse_StatusIsIncorrect_ReturnsException()
        {
            var handler = (IRequestHandler<AddCourseCommand>)_addHandler;


            await Should.ThrowAsync<EntityIsNotFoundException>(() =>

                 handler.Handle(new AddCourseCommand
                 {
                     Status = (CourseStatuses)8
                 }, new System.Threading.CancellationToken())
             );

        }

        [Fact]
        public async Task AddCourse_AddInRepo_AddedRow()
        {
            var handler = (IRequestHandler<AddCourseCommand>)_addHandler;

            var addItem = new AddCourseCommand
            {
                Status = CourseStatuses.Closed,
                Description = "Описание",
                Name = "Название"

            };


            await handler.Handle(addItem, new System.Threading.CancellationToken());

            _courceRepository.Setup(x => x.CreateAsync(It.IsAny<DBCource>())).Callback<DBCource>((item) =>
            {
                item.ShouldBeSameAs(addItem);
            });

        }

    }


}
