using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class ChatService : IChatService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository, IUnitOfWork unitOfWork)
        {
            _chatRepository = chatRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatResponse> Delete(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");

            try
            {
                _chatRepository.Remove(existingChat);
                return new ChatResponse(existingChat);
            }
            catch (Exception ex)
            {
                return new ChatResponse($"An error ocurred while deleting Chat: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _chatRepository.ListAsync();
        }

        public async Task<ChatResponse> SaveAsync(Chat chat, int user1Id, int user2Id)
        {
            var existingUser1 = await _userRepository.FindById(user1Id);
            if (existingUser1 == null)
            {
                return new ChatResponse("User not found");
            }
            var existingUser2 = await _userRepository.FindById(user2Id);
            if (existingUser2 == null)
            {
                return new ChatResponse("User not found");
            }

            chat.User1 = existingUser1;
            chat.User2 = existingUser2;

            try
            {
                await _chatRepository.AddAsync(chat);
                return new ChatResponse(chat);
            }
            catch (Exception ex)
            {
                return new ChatResponse(
                    $"An error ocurred while saving the Message: {ex.Message}");
            }

        }

        public async Task<ChatResponse> GetByIdAsync(int id)
        {
            var existingChat = await _chatRepository.FindById(id);
            if (existingChat == null)
                return new ChatResponse("Chat not found");
            return new ChatResponse(existingChat);
        }
    }
}
