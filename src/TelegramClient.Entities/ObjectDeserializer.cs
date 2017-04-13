﻿using System;
using System.IO;
using System.Reflection;

namespace TelegramClient.Entities
{
    public class ObjectUtils
    {
        public static object DeserializeObject(BinaryReader reader)
        {
            var Constructor = reader.ReadInt32();
            object obj;
            TypeInfo t;
            try
            {
                t = TLContext.GetType(Constructor).GetTypeInfo();
                obj = Activator.CreateInstance(t.AsType());
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Constructor Invalid Or Context.Init Not Called !", ex);
            }
            if (t.IsSubclassOf(typeof(TLMethod)))
            {
                ((TLMethod) obj).deserializeResponse(reader);
                return obj;
            }
            if (t.IsSubclassOf(typeof(TLObject)))
            {
                ((TLObject) obj).DeserializeBody(reader);
                return obj;
            }
            throw new NotImplementedException("Weird Type : " + t.Namespace + " | " + t.Name);
        }

        public static void SerializeObject(object obj, BinaryWriter writer)
        {
            ((TLObject) obj).SerializeBody(writer);
        }

        public static TLVector<T> DeserializeVector<T>(BinaryReader reader)
        {
            if (reader.ReadInt32() != 481674261) throw new InvalidDataException("Bad Constructor");
            var t = new TLVector<T>();
            t.DeserializeBody(reader);
            return t;
        }
    }
}