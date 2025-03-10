﻿namespace ApiProject.WebApi.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
