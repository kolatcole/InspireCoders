using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InspireCoders.Domain.Core.Implementation
{
    public static class EnumService
    {
        public static PermEntity GetPermission(this Enum value)
        {
            return GetEnumPermission((PermEnums)value);
        }

        public static PermEntity GetEnumPermission(PermEnums value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = attributes[0].Description;
            var index = description.IndexOf(' ');
            return new PermEntity
            {
                Permission = value,
                Code = ((int)value).ToString(),
                Name = description,
                Action = description.Substring(0, index),
                Entity = description.Substring(index)
            };
        }
    }
}
