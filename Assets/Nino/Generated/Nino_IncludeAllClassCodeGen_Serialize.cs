/* this is generated by nino */
namespace Nino
{
    public partial class IncludeAllClassCodeGen
    {
        public static IncludeAllClassCodeGen.SerializationHelper NinoSerializationHelper = new IncludeAllClassCodeGen.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<IncludeAllClassCodeGen>
        {
            #region NINO_CODEGEN
            public override void Serialize(IncludeAllClassCodeGen value, Nino.Serialization.Writer writer)
            {
                writer.CompressAndWrite(ref value.a);
                writer.CompressAndWrite(ref value.b);
                writer.Write(value.c);
                writer.Write(value.d);
            }

            public override IncludeAllClassCodeGen Deserialize(Nino.Serialization.Reader reader)
            {
                IncludeAllClassCodeGen value = new IncludeAllClassCodeGen();
                reader.DecompressAndReadNumber<System.Int32>(ref value.a);
                reader.DecompressAndReadNumber<System.Int64>(ref value.b);
                reader.Read<System.Single>(ref value.c, Nino.Shared.Mgr.ConstMgr.SizeOfUInt);
                reader.Read<System.Double>(ref value.d, Nino.Shared.Mgr.ConstMgr.SizeOfULong);
                return value;
            }
            #endregion
        }
    }
}