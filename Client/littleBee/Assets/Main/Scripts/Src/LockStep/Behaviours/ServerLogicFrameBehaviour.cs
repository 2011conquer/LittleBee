﻿using NetServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Synchronize.Game.Lockstep.Behaviours
{
    public class ServerLogicFrameBehaviour : ISimulativeBehaviour
    {
        public Simulation Sim
        {
            set;get;
        }
        public int CurrentFrameIdx { private set; get; }

        public void Quit()
        {
            
        }

        public void Start()
        {
            CurrentFrameIdx = -1;
        }

        public void Update()
        {
            ++CurrentFrameIdx;
        }
    }
}
