﻿
using NetServiceImpl;
using NetServiceImpl.OnlineMode.Room;
using Synchronize.Game.Lockstep.Behaviours.Data;
using Synchronize.Game.Lockstep.Behaviours.Frame;
using Synchronize.Game.Lockstep.Frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSync;
using UnityEngine;

namespace Synchronize.Game.Lockstep.Behaviours
{
    public class JoystickMovementInputBehaviour : ISimulativeBehaviour
    {
        uint Id;
        JoystickMovementInputRecord currentRecord;
        JoystickMovementInputRecord record;
        public Simulation Sim { set; get; }
        LogicFrameBehaviour logic;
        public void Quit()
        {
            
        }

        public void Start()
        {
            Id = ClientService.Get<RoomServices>().Session.Id;
            logic = Sim.GetBehaviour<LogicFrameBehaviour>();
            currentRecord = new JoystickMovementInputRecord();
            currentRecord.EntityId = Id;
            record = new JoystickMovementInputRecord();
            record.EntityId = Id;
        }

        public void Update()
        {
            if (Id > 0)
            {
                if( Joystick.Instance != null)
                {
                    TSVector2 currentJoystickDir = Joystick.Instance.GetCurrentDirection();

                    currentRecord.x = currentJoystickDir.x;
                    currentRecord.y = currentJoystickDir.y;
                    if (record.IsDirty(currentRecord))
                    {
                        record.CopyFrom(currentRecord);
                        KeyFrameSender.AddCurrentFrameCommand(logic.CurrentFrameIdx, FrameCommand.SYNC_MOVE, Id, 
                            new ByteBuffer().WriteByte(Const.INPUT_TYPE_JOYSTICK).WriteInt64(currentRecord.x._serializedValue).WriteInt64(currentRecord.y._serializedValue).Getbuffer());
                    }
                }
            }
        }
    }
}
