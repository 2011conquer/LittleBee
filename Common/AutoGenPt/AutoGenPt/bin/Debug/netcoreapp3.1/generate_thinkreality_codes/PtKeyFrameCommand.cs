//Template auto generator:[AutoGenPt] v1.0
//Creation time:2021/6/30 11:58:47
using System;
using System.Collections;
using System.Collections.Generic;
namespace Lenovo.XR.Development.Net.Pt
{
public class PtKeyFrameCommand
{
    public byte __tag__ { get;private set;}

	public int FrameIndex{ get;private set;}
	public uint Command{ get;private set;}
	public uint EntityId{ get;private set;}
	public List<string> ParamDatas{ get;private set;}
	   
    public PtKeyFrameCommand SetFrameIndex(int value){FrameIndex=value; __tag__|=1; return this;}
	public PtKeyFrameCommand SetCommand(uint value){Command=value; __tag__|=2; return this;}
	public PtKeyFrameCommand SetEntityId(uint value){EntityId=value; __tag__|=4; return this;}
	public PtKeyFrameCommand SetParamDatas(List<string> value){ParamDatas=value; __tag__|=8; return this;}
	
    public bool HasFrameIndex(){return (__tag__&1)==1;}
	public bool HasCommand(){return (__tag__&2)==2;}
	public bool HasEntityId(){return (__tag__&4)==4;}
	public bool HasParamDatas(){return (__tag__&8)==8;}
	
    public static byte[] Write(PtKeyFrameCommand data)
    {
        using(ByteBuffer buffer = new ByteBuffer())
        {
            buffer.WriteByte(data.__tag__);
			if(data.HasFrameIndex())buffer.WriteInt32(data.FrameIndex);
			if(data.HasCommand())buffer.WriteUInt32(data.Command);
			if(data.HasEntityId())buffer.WriteUInt32(data.EntityId);
			if(data.HasParamDatas())buffer.WriteCollection(data.ParamDatas,element=>buffer.WriteString(element));
			
            return buffer.Getbuffer();
        }
    }

    public static PtKeyFrameCommand Read(byte[] bytes)
    {
        using(ByteBuffer buffer = new ByteBuffer(bytes))
        {
            PtKeyFrameCommand data = new PtKeyFrameCommand();
            data.__tag__ = buffer.ReadByte();
			if(data.HasFrameIndex())data.FrameIndex = buffer.ReadInt32();
			if(data.HasCommand())data.Command = buffer.ReadUInt32();
			if(data.HasEntityId())data.EntityId = buffer.ReadUInt32();
			if(data.HasParamDatas())data.ParamDatas = buffer.ReadCollection(()=>buffer.ReadString());
			
            return data;
        }       
    }
}
}
