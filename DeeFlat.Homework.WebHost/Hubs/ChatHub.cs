using DeeFlat.Abstractions.Repositories;
using DeeFlat.Homework.Core.Domain;
using DeeFlat.Homework.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.Homework.WebHost.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IRepository<Chat> _chatResitory;
        private IRepository<ChatMessage> _chatMessagesRepository;

        public ChatHub(IRepository<Chat> chatResitory, 
            IRepository<ChatMessage> chatMessagesResository)
        {
            _chatResitory = chatResitory;
            _chatMessagesRepository = chatMessagesResository;
        }

        public async Task<IEnumerable<ChatMessage>> JoinChatAsPupil(string userId, string courseId)
        {
            if (Guid.TryParse(userId, out Guid parsedUserId) 
                || Guid.TryParse(courseId, out Guid parsedCourseId))
            {
                throw new ArgumentNullException("UserId and CourseId are null");
            }

            var chat = await _chatResitory.GetFirstWhereAsync(c => c.CourseId == parsedCourseId && c.PupilId == parsedUserId);

            if (chat == null)
            {
                chat = new Chat() { CourseId = parsedCourseId, PupilId = parsedUserId };
                await _chatResitory.CreateAsync(chat);
            }
            
            var messages = (await _chatMessagesRepository.GetWhereAsync(cm => cm.CourseId == parsedCourseId))
                .OrderBy(m => m.MessageIndex)
                .ToList();

            await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());

            return messages;
        }


        public async Task SendMessageAsync(string fromUserId, string courseId, string content)
        {
            if (Guid.TryParse(fromUserId, out Guid parsedUserId)
                || Guid.TryParse(courseId, out Guid parsedCourseId))
            {
                throw new ArgumentNullException("fromUserId and courseId are null");
            }

            var chat = await _chatResitory.GetFirstWhereAsync(c => c.CourseId == parsedCourseId && c.PupilId == parsedUserId);

            if (chat.PupilId != parsedUserId) throw new Exception("You cannot use this chat");

            var chatMessage = new ChatMessage() { CourseId = parsedCourseId, FromUserId = parsedUserId, Content = content };

            await _chatMessagesRepository.CreateAsync(chatMessage);

            await Clients.Group(chat.Id.ToString()).SendAsync("ReceiveChatMessage", chatMessage);
        }

        public async Task SendMessageAsTeacherAsync(string fromUserId, string courseId, string content)
        {
            if (Guid.TryParse(fromUserId, out Guid parsedUserId)
                || Guid.TryParse(courseId, out Guid parsedCourseId))
            {
                throw new ArgumentNullException("fromUserId and courseId are null");
            }

            var chat = await _chatResitory.GetFirstWhereAsync(c => c.CourseId == parsedCourseId && c.PupilId == parsedUserId);

            chat.AssignedTeacherId = parsedUserId;
            var chatMessage = new ChatMessage() { CourseId = parsedCourseId, FromUserId = parsedUserId, Content = content };

            await _chatResitory.UpdateAsync(chat);

            await Clients.Group(chat.Id.ToString()).SendAsync("ReceiveChatMessage", chatMessage);
        }
    }
}
