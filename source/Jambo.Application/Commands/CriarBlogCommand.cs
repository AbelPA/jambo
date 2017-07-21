﻿using MediatR;
using System.Runtime.Serialization;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class CriarBlogCommand: IRequest<bool>
    {
        [DataMember]
        public string Url { get; private set; }

        [DataMember]
        public int Rating { get; private set; }

        public CriarBlogCommand()
        {

        }

        public CriarBlogCommand(string url, int rating) : this()
        {
            Url = url;
            Rating = rating;
        }
    }
}