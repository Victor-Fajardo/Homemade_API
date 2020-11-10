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
    public class MessageService : IMessageService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            var existingMessage = await _messageRepository.FindById(id);
            if (existingMessage == null)
                return new MessageResponse("Message not found");

            try
            {
                _messageRepository.Remove(existingMessage);
                return new MessageResponse(existingMessage);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"An error ocurred while deleting Message: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
        }

        public async Task<IEnumerable<Message>> ListByChatIdAsync(int chatId)
        {
            return await _messageRepository.ListBychatIdAsync(chatId);
        }

        public async Task<MessageResponse> SaveAsync(Message message, int ChatId, int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            if (existingUser == null)
            {
                return new MessageResponse("User not found");
            }

            message.User = existingUser;

            try
            {
                await _messageRepository.AddAsync(message);
                return new MessageResponse(message);
            }
            catch (Exception ex)
            {
                return new MessageResponse(
                    $"An error ocurred while saving the Message: {ex.Message}");
            }
        }

        public async Task<MessageResponse> GetByIdAsync(int id)
        {
            var existingMessage = await _messageRepository.FindById(id);
            if (existingMessage == null)
                return new MessageResponse("Message not found");
            return new MessageResponse(existingMessage);
        }
    }
}
