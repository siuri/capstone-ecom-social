using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public int SubjectId { get; set; }

        public int? SubjectTypeId { get; set; }
        [ForeignKey("SubjectTypeId")]
        public virtual PronounsType SubjectType { get; set; }


        public int ObjectId { get; set; }

        public int? ObjectTypeId { get; set; }
        [ForeignKey("ObjectTypeId")]
        public virtual PronounsType ObjectType { get; set; }

        public int? MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public virtual MessageType MessageType { get; set; }

        public virtual ICollection<MessageRecipient> Recipients { get; set; }
    }

    public class PronounsType
    {
        public int PronounsTypeId { get; set; }
        public string PronounsTypeName { get; set; }
    }

    public class MessageType
    {
        public int MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }

        public string Content { get; set; }
    }

    public class MessageRecipient
    {
        public int MessageRecipientId { get; set; }

        public int? RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public virtual UserProfile Recipient { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }

        public int? MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }

    }

    public class MessageJson
    {
        public int MessageId { get; set; }
        public ObjJson Subj { get; set; }
        public string Verb { get; set; }
        public ObjJson Obj { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ObjJson
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}