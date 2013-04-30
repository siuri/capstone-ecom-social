using Capstone_20130302.Constants;
using Capstone_20130302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Logic
{
    public class Message_Logic
    {
        private static SocialBuyContext db = new SocialBuyContext();

        public static bool PublishMessage(int SubjId, int SubjType, int ObjId, int ObjType, int MsgType)
        {
            // SubjId is Publisher
            List<UserProfile> subscribers = Follow_Logic.GetFollowingUsersOfType(2, SubjId, -1);
            // Send message to shop owner
            if (MsgType == Constant.MESSAGE_TYPE_COMMENT)
            {
                Product pro = db.Products.Find(ObjId);
                if (pro != null && subscribers.Contains(pro.Store.Owner) == false)
                {
                    subscribers.Add(pro.Store.Owner);
                }
            }
            // Send message to follow destination user
            if (MsgType == Constant.MESSAGE_TYPE_FOLLOW)
            {
                if (ObjType == Constant.PRONOUN_TYPE_USER)
                {
                    UserProfile user = db.UserProfiles.Find(ObjId);
                    if (user != null && subscribers.Contains(user) == false)
                    {
                        subscribers.Add(user);
                    }
                }
                else if (ObjType == Constant.PRONOUN_TYPE_STORE)
                {
                    Store store = db.Stores.Find(ObjId);
                    if (store != null && subscribers.Contains(store.Owner) == false)
                    {
                        subscribers.Add(store.Owner);
                    }
                }
            }
            List<MessageRecipient> recipients = new List<MessageRecipient>();
            MessageRecipient r = null;
            foreach (var s in subscribers)
            {
                if (s != null)
                {
                    r = new MessageRecipient { RecipientId = s.UserId, CreateDate = DateTime.Now, IsRead = false };
                    recipients.Add(r);
                }
            }
            Message msg = new Message
            {
                SubjectId = SubjId,
                SubjectTypeId = SubjType,
                ObjectId = ObjId,
                ObjectTypeId = ObjType,
                MessageTypeId = MsgType,
                Recipients = recipients
            };
            try
            {
                db.Messages.Add(msg);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public static List<MessageJson> GetNewsFeed(int UserId, int LastMessageId = 0)
        {
            List<Message> messages = null;
            if (LastMessageId == 0)
            {
                // load all messages at first
                messages = (from message in db.Messages
                            from recipient in db.MessageRecipients
                            where message.MessageId == recipient.MessageId
                            && recipient.RecipientId == UserId
                            orderby message.MessageId
                            select message).ToList();
            }
            else
            {
                // load new messages only
                messages = (from message in db.Messages
                            from recipient in db.MessageRecipients
                            where message.MessageId == recipient.MessageId
                            && recipient.RecipientId == UserId && recipient.MessageId > LastMessageId 
                            && recipient.IsRead == false
                            orderby message.MessageId
                            select message).ToList();
            }
            List<MessageType> types = db.MessageTypes.ToList();
            List<MessageJson> msgJsonList = new List<MessageJson>();
            MessageJson msgJson = null;
            ObjJson subJson = null;
            ObjJson objJson = null;
            MessageRecipient rep = null;
            foreach (var m in messages)
            {
                msgJson = new MessageJson();
                subJson = new ObjJson();
                objJson = new ObjJson();
                switch (m.SubjectTypeId)
                {
                    case Constant.PRONOUN_TYPE_USER :
                        UserProfile user = db.UserProfiles.Find(m.SubjectId);
                        subJson.Id = user.UserId;
                        subJson.ImageId = user.Profile.ProfileImageId;
                        subJson.Name = user.Profile.DisplayName;
                        subJson.Url = "/User/Id/" + user.UserId;
                        break;
                    case Constant.PRONOUN_TYPE_STORE :
                        Store store = db.Stores.Find(m.SubjectId);
                        subJson.Id = store.StoreId;
                        subJson.ImageId = store.CoverImageId;
                        subJson.Name = store.StoreName;
                        subJson.Url = "/Store/Id/" + store.StoreId;
                        break;
                    case Constant.PRONOUN_TYPE_PRODUCT :
                        Product product = db.Products.Find(m.SubjectId);
                        subJson.Id = product.ProductId;
                        subJson.ImageId = product.ProductImages.First().ImageId;
                        subJson.Name = product.Name;
                        subJson.Url = "/Product/Id/" + product.ProductId;
                        break;
                    case Constant.PRONOUN_TYPE_CATEGORY :
                        Category category = db.Categories.Find(m.SubjectId);
                        subJson.Id = category.CategoryId;
                        subJson.ImageId = category.CoverImageId;
                        subJson.Name = category.Name;
                        subJson.Url = "/Category/Id/" + category.CategoryId;
                        break;
                }
                switch (m.ObjectTypeId)
                {
                    case Constant.PRONOUN_TYPE_USER:
                        UserProfile user = db.UserProfiles.Find(m.ObjectId);
                        objJson.Id = user.UserId;
                        objJson.ImageId = user.Profile.ProfileImageId;
                        objJson.Name = user.Profile.DisplayName;
                        objJson.Url = "/User/Id/" + user.UserId;
                        break;
                    case Constant.PRONOUN_TYPE_STORE:
                        Store store = db.Stores.Find(m.ObjectId);
                        objJson.Id = store.StoreId;
                        objJson.ImageId = store.CoverImageId;
                        objJson.Name = store.StoreName;
                        objJson.Url = "/Store/Id/" + store.StoreId;
                        break;
                    case Constant.PRONOUN_TYPE_PRODUCT:
                        Product product = db.Products.Find(m.ObjectId);
                        objJson.Id = product.ProductId;
                        objJson.ImageId = product.ProductImages.First().ImageId;
                        objJson.Name = product.Name;
                        objJson.Url = "/Product/Id/" + product.ProductId;
                        break;
                    case Constant.PRONOUN_TYPE_CATEGORY:
                        Category category = db.Categories.Find(m.ObjectId);
                        objJson.Id = category.CategoryId;
                        objJson.ImageId = category.CoverImageId;
                        objJson.Name = category.Name;
                        objJson.Url = "/Category/Id/" + category.CategoryId;
                        break;
                }
                rep = m.Recipients.Where(r => r.RecipientId == UserId).FirstOrDefault();
                msgJsonList.Add(new MessageJson { MessageId = m.MessageId, Subj = subJson, Verb = m.MessageType.Content, Obj = objJson, IsRead = rep.IsRead, CreateDate = rep.CreateDate });
            }
            return msgJsonList;
        }
    }
}