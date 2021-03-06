﻿using System;

// TODO: change namespace in 3.0 version
namespace DbLocalizationProvider
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public class ResourceKeyAttribute : Attribute
    {
        public ResourceKeyAttribute(string key) : this(key, null) { }

        public ResourceKeyAttribute(string key, string value)
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; set; }
    }
}
