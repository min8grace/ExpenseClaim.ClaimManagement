﻿using System;

namespace KakaoExpenseClaim.ClaimManagement.Api.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

        public string ContentType { get; }
    }
}