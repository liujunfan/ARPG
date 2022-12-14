/* this is generated by nino */
namespace Nino
{
    public partial struct MyStruct
    {
        public static MyStruct.SerializationHelper NinoSerializationHelper = new MyStruct.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<MyStruct>
        {
            #region NINO_CODEGEN
            public override void Serialize(MyStruct value, Nino.Serialization.Writer writer)
            {
                writer.CompressAndWrite(ref value.a);
                if(value.b != null)
                {
                    writer.CompressAndWrite(value.b.Count);
                    foreach (var entry in value.b)
                    {
                        writer.CompressAndWrite(entry);
                    }
                }
                else
                {
                    writer.CompressAndWrite(0);
                }
            }

            public override MyStruct Deserialize(Nino.Serialization.Reader reader)
            {
                MyStruct value = new MyStruct();
                reader.DecompressAndReadNumber<System.Int32>(ref value.a);
                value.b = new System.Collections.Generic.List<System.Int32>(reader.ReadLength());
                for(int i = 0, cnt = value.b.Capacity; i < cnt; i++)
                {
                    var value_b_i = reader.DecompressAndReadNumber<System.Int32>();
                    value.b.Add(value_b_i);
                }
                return value;
            }
            #endregion
        }
    }
}