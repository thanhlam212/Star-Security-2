using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common.ValueObjects
{
    public class Email
    {
        public string Value { get; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(value));
            }

            // Kiểm tra xem chuỗi có đúng định dạng email không
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format", nameof(value));
            }
            Value = value;
        }

        private bool IsValidEmail(string value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == value;
            }
            catch
            {
                return false;
            }
        }
    }
}
