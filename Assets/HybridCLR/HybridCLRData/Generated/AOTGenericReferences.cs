public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ constraint implement type
	// }} 

	// {{ AOT generic type
	//Nino.Serialization.NinoWrapperBase`1<System.Object>
	//Nino.Serialization.NinoWrapperBase`1<Nino.MyStruct>
	//System.Action`1<System.Object>
	//System.Action`2<System.Object,System.Double>
	//System.Action`2<System.Object,UnityEngine.Vector4>
	//System.Action`2<System.Object,System.UInt64>
	//System.Action`2<System.Object,System.UInt32>
	//System.Action`2<System.Int32,System.Object>
	//System.Action`2<System.Object,System.UInt16>
	//System.Action`2<System.Object,System.Object>
	//System.Action`2<System.Object,UnityEngine.Vector3>
	//System.Action`2<System.Object,System.SByte>
	//System.Action`2<System.Object,System.Int64>
	//System.Action`2<System.Object,System.DateTime>
	//System.Action`2<System.Object,System.Int16>
	//System.Action`2<System.Object,UnityEngine.Vector2>
	//System.Action`2<System.Object,System.Decimal>
	//System.Action`2<System.Object,System.Byte>
	//System.Action`2<System.Object,System.Single>
	//System.Action`2<System.Object,System.Int32>
	//System.Collections.Generic.Dictionary`2<System.Int32,System.Byte>
	//System.Collections.Generic.Dictionary`2<System.Object,System.Byte>
	//System.Collections.Generic.Dictionary`2<System.Byte,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Object,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Int64,System.Object>
	//System.Collections.Generic.Dictionary`2<System.Object,System.Int32>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Int32>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Int32,System.Byte>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Byte>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Byte,System.Object>
	//System.Collections.Generic.Dictionary`2/Enumerator<System.Object,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection<System.Object,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection<System.Int64,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection/Enumerator<System.Object,System.Object>
	//System.Collections.Generic.Dictionary`2/ValueCollection/Enumerator<System.Int64,System.Object>
	//System.Collections.Generic.ICollection`1<UnityEngine.Vector3>
	//System.Collections.Generic.ICollection`1<System.Single>
	//System.Collections.Generic.IEnumerator`1<System.Object>
	//System.Collections.Generic.IList`1<System.Single>
	//System.Collections.Generic.IList`1<UnityEngine.Vector3>
	//System.Collections.Generic.KeyValuePair`2<System.Byte,System.Object>
	//System.Collections.Generic.KeyValuePair`2<System.Int32,System.Byte>
	//System.Collections.Generic.KeyValuePair`2<System.Object,System.Int32>
	//System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>
	//System.Collections.Generic.KeyValuePair`2<System.Object,System.Byte>
	//System.Collections.Generic.List`1<System.Int32>
	//System.Collections.Generic.List`1<UnityEngine.Vector2>
	//System.Collections.Generic.List`1<System.Single>
	//System.Collections.Generic.List`1<System.Object>
	//System.Collections.Generic.List`1<UnityEngine.Quaternion>
	//System.Collections.Generic.List`1/Enumerator<UnityEngine.Quaternion>
	//System.Collections.Generic.List`1/Enumerator<System.Object>
	//System.Collections.Generic.List`1/Enumerator<System.Int32>
	//System.Collections.Generic.Queue`1<System.Object>
	//System.Collections.Generic.Stack`1<System.Int32>
	//System.Collections.Generic.Stack`1<System.Object>
	//System.Comparison`1<System.Int32>
	//System.Func`2<System.Object,System.Double>
	//System.Func`2<System.Object,UnityEngine.Vector3>
	//System.Func`2<System.Object,UnityEngine.Vector4>
	//System.Func`2<System.Object,System.Single>
	//System.Func`2<System.Object,System.UInt64>
	//System.Func`2<System.Object,System.UInt32>
	//System.Func`2<System.Object,System.UInt16>
	//System.Func`2<System.Object,System.SByte>
	//System.Func`2<System.Object,System.Int32>
	//System.Func`2<System.Int32,System.Single>
	//System.Func`2<System.Object,System.DateTime>
	//System.Func`2<System.Object,System.Int16>
	//System.Func`2<System.Object,System.Decimal>
	//System.Func`2<System.Object,System.Byte>
	//System.Func`2<System.Object,System.Object>
	//System.Func`2<System.Object,UnityEngine.Vector2>
	//System.Func`2<System.Object,System.Int64>
	//System.Func`3<System.Single,System.Single,System.Single>
	//System.Nullable`1<System.Int32>
	//System.Predicate`1<UnityEngine.SceneManagement.Scene>
	//System.Predicate`1<System.Object>
	//TMPro.FastAction`1<System.Object>
	//UnityEngine.Events.UnityAction`1<System.Object>
	//UnityEngine.Events.UnityAction`2<System.UInt16,System.Int32>
	//UnityEngine.Events.UnityAction`3<System.Object,System.Object,System.Int32>
	//UnityEngine.Events.UnityAction`3<System.Object,System.Int32,System.Int32>
	//UnityEngine.Events.UnityEvent`1<System.Object>
	//UnityEngine.Events.UnityEvent`2<System.UInt16,System.Int32>
	//UnityEngine.Events.UnityEvent`3<System.Object,System.Object,System.Int32>
	//UnityEngine.Events.UnityEvent`3<System.Object,System.Int32,System.Int32>
	// }}

	public void RefMethods()
	{
		// Nino.MyStruct Nino.Serialization.Deserializer::Deserialize<Nino.MyStruct>(System.Byte[],System.Text.Encoding,Nino.Serialization.CompressOption)
		// System.Void Nino.Serialization.Reader::DecompressAndReadEnum<Nino.TestEnum>(Nino.TestEnum&)
		// System.Void Nino.Serialization.Reader::DecompressAndReadNumber<System.Int64>(System.Int64&)
		// System.Int32 Nino.Serialization.Reader::DecompressAndReadNumber<System.Int32>()
		// System.Void Nino.Serialization.Reader::DecompressAndReadNumber<System.Int32>(System.Int32&)
		// System.Void Nino.Serialization.Reader::Read<System.Int16>(System.Int16&,System.Int32)
		// System.Void Nino.Serialization.Reader::Read<System.Byte>(System.Byte&,System.Int32)
		// System.Void Nino.Serialization.Reader::Read<System.Double>(System.Double&,System.Int32)
		// System.Void Nino.Serialization.Reader::Read<System.Decimal>(System.Decimal&,System.Int32)
		// System.Void Nino.Serialization.Reader::Read<System.Single>(System.Single&,System.Int32)
		// System.Nullable`1<System.Int32> Nino.Serialization.Reader::ReadCommonVal<System.Nullable`1<System.Int32>>()
		// UnityEngine.Vector3 Nino.Serialization.Reader::ReadCommonVal<UnityEngine.Vector3>()
		// UnityEngine.Quaternion Nino.Serialization.Reader::ReadCommonVal<UnityEngine.Quaternion>()
		// UnityEngine.Matrix4x4 Nino.Serialization.Reader::ReadCommonVal<UnityEngine.Matrix4x4>()
		// System.Byte[] Nino.Serialization.Serializer::Serialize<Nino.MyStruct>(Nino.MyStruct,System.Text.Encoding,Nino.Serialization.CompressOption)
		// System.Void Nino.Serialization.Writer::CompressAndWriteEnum<Nino.TestEnum>(Nino.TestEnum)
		// System.Void Nino.Serialization.Writer::WriteCommonVal<System.Nullable`1<System.Int32>>(System.Nullable`1<System.Int32>)
		// System.Void Nino.Serialization.Writer::WriteCommonVal<UnityEngine.Quaternion>(UnityEngine.Quaternion)
		// System.Void Nino.Serialization.Writer::WriteCommonVal<UnityEngine.Matrix4x4>(UnityEngine.Matrix4x4)
		// System.Void Nino.Serialization.Writer::WriteCommonVal<UnityEngine.Vector3>(UnityEngine.Vector3)
		// System.Object System.Activator::CreateInstance<System.Object>()
		// System.Void System.Array::Resize<Nono.LinkedList`1/Node<Nono.TaskMonitor/Item>>(Nono.LinkedList`1/Node<Nono.TaskMonitor/Item>[]&,System.Int32)
		// System.Collections.Generic.IEnumerable`1<System.Object> System.Linq.Enumerable::Select<System.Object,System.Object>(System.Collections.Generic.IEnumerable`1<System.Object>,System.Func`2<System.Object,System.Object>)
		// System.Collections.Generic.IEnumerable`1<System.Int32> System.Linq.Enumerable::SelectMany<System.Object,System.Int32>(System.Collections.Generic.IEnumerable`1<System.Object>,System.Func`2<System.Object,System.Collections.Generic.IEnumerable`1<System.Int32>>)
		// System.Collections.Generic.IEnumerable`1<System.Object> System.Linq.Enumerable::SelectMany<System.Object,System.Object>(System.Collections.Generic.IEnumerable`1<System.Object>,System.Func`2<System.Object,System.Collections.Generic.IEnumerable`1<System.Object>>)
		// System.Object[] System.Linq.Enumerable::ToArray<System.Object>(System.Collections.Generic.IEnumerable`1<System.Object>)
		// System.Int32[] System.Linq.Enumerable::ToArray<System.Int32>(System.Collections.Generic.IEnumerable`1<System.Int32>)
		// System.Collections.Generic.List`1<System.Object> System.Linq.Enumerable::ToList<System.Object>(System.Collections.Generic.IEnumerable`1<System.Object>)
		// System.String System.String::Join<System.Object>(System.String,System.Collections.Generic.IEnumerable`1<System.Object>)
		// System.String System.String::Join<System.Int32>(System.String,System.Collections.Generic.IEnumerable`1<System.Int32>)
		// System.String System.String::Join<UnityEngine.Quaternion>(System.String,System.Collections.Generic.IEnumerable`1<UnityEngine.Quaternion>)
		// System.Object System.Threading.Interlocked::CompareExchange<System.Object>(System.Object&,System.Object,System.Object)
		// System.Object UnityEngine.Component::GetComponent<System.Object>()
		// System.Object UnityEngine.Component::GetComponentInChildren<System.Object>()
		// System.Object UnityEngine.GameObject::AddComponent<System.Object>()
		// System.Object UnityEngine.GameObject::GetComponent<System.Object>()
		// System.Object UnityEngine.GameObject::GetComponentInParent<System.Object>()
		// System.Object UnityEngine.Object::Instantiate<System.Object>(System.Object)
		// System.Object UnityEngine.Resources::Load<System.Object>(System.String)
	}
}