/* this is generated by nino */
namespace Nino
{
    public partial class Data
    {
        public static Data.SerializationHelper NinoSerializationHelper = new Data.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<Data>
        {
            #region NINO_CODEGEN
            public override void Serialize(Data value, Nino.Serialization.Writer writer)
            {
                writer.CompressAndWrite(ref value.x);
                writer.Write(value.y);
                writer.CompressAndWrite(ref value.z);
                writer.Write(value.f);
                writer.Write(value.d);
                writer.Write(value.db);
                writer.Write(value.bo);
                writer.CompressAndWriteEnum<Nino.TestEnum>(value.en);
                writer.Write(value.name);
            }

            public override Data Deserialize(Nino.Serialization.Reader reader)
            {
                Data value = new Data();
                reader.DecompressAndReadNumber<System.Int32>(ref value.x);
                reader.Read<System.Int16>(ref value.y, Nino.Shared.Mgr.ConstMgr.SizeOfShort);
                reader.DecompressAndReadNumber<System.Int64>(ref value.z);
                reader.Read<System.Single>(ref value.f, Nino.Shared.Mgr.ConstMgr.SizeOfUInt);
                reader.Read<System.Decimal>(ref value.d, Nino.Shared.Mgr.ConstMgr.SizeOfDecimal);
                reader.Read<System.Double>(ref value.db, Nino.Shared.Mgr.ConstMgr.SizeOfULong);
                reader.Read<System.Boolean>(ref value.bo, 1);
                reader.DecompressAndReadEnum<Nino.TestEnum>(ref value.en);
                value.name = reader.ReadString();
                return value;
            }
            #endregion
        }
    }
}