﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntitySyncingClient
{
    internal static class ProtobufSerializer
    {
        /// <summary>
        /// Deserializes protobuf object from byte[]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeProtobuf<T>(this byte[] data)
        {
            T ret = default(T);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
            {

                ret = ProtoBuf.Serializer.Deserialize<T>(ms);
                ms.Close();
            }

            return ret;
        }

        /// <summary>
        /// Protobuffed deepclone
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CloneProtobuf<T>(this T obj)
        {
            return ProtoBuf.Serializer.DeepClone<T>(obj);
        }

        /// <summary>
        /// Deserializes protobuf object from byte[]. Non-generic style.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static object DeserializeProtobuf(byte[] data, Type T)
        {
            object ret = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
            {

                ret = ProtoBuf.Serializer.NonGeneric.Deserialize(T, ms);
                ms.Close();
            }

            return ret;
        }

        /// <summary>
        /// Serialize object using protobuf serializer
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SerializeProtobuf(this object data)
        {
            byte[] bt = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ProtoBuf.Serializer.NonGeneric.Serialize(ms, data);
                bt = ms.ToArray();
                ms.Close();
            }

            return bt;
        }
    }
}
