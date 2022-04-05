using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfLearnSignUp.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CreatedAt { get; set; }

        public string EditedAt { get; set; }

        public string DeletedAt { get; set; }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        public char Status { get; set; }

        public void SetId(int Id)
        {
            this.Id = Id;
        }
        public int GetId()
        {
            return this.Id;
        }

        public void SetCreatedAt(string CreatedAt)
        {
            this.CreatedAt = CreatedAt;
        }

        public string GetCreatedAt()
        {
            return this.CreatedAt;
        }

        public void SetEditedAt(string EditedAt)
        {
            this.EditedAt = EditedAt;
        }

        public string GetEditedAt()
        {
            return this.EditedAt;
        }

        public void SetDeletedAt(string DeletedAt)
        {
            this.DeletedAt = DeletedAt;
        }

        public string GetDeletedAt()
        {
            return this.DeletedAt;
        }

        public void SetFirstName(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public void SetLastName(string LastName)
        {
            this.LastName = LastName;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public void SetContactNo(string ContactNo)
        {
            this.ContactNo = ContactNo;
        }
        public string GetContactNo()
        {
            return this.ContactNo;
        }
        public void SetEmailId(string EmailId)
        {
            this.EmailId = EmailId;
        }
        public string GetEmailId()
        {
            return this.EmailId;
        }

        public void SetGender(char Gender)
        {
            this.Gender = Gender;
        }
        public char GetGender()
        {
            return this.Gender;
        }

        public void SetStatus(char Status)
        {
            this.Status = Status;
        }
        public char GetStatus()
        {
            return this.Status;
        }
    }
}