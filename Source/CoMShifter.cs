﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// this code is by asmi
// used with permission

namespace RealismOverhaul
{
    class CoMShifter : PartModule
    {
        [KSPField]
        public Vector3 DescentModeCoM;

        [KSPField(guiActive = true, guiName = "Descent Mode Active?", isPersistant = true)]
        public bool IsDescentMode;

        private Vector3 _defaultCoM;

        [KSPEvent(guiName = "Toggle Descent Mode", guiActive = true)]
        public void ToggleMode()
        {
            IsDescentMode = !IsDescentMode;
            SetDescentMode(IsDescentMode);
        }

        private void SetDescentMode(bool isOn)
        {
            if (isOn)
            {
                part.CoMOffset = DescentModeCoM + _defaultCoM;
            }
            else
            {
                part.CoMOffset = _defaultCoM;
            }
        }

        [KSPAction("Toggle Descent Mode")]
        public void Toggle(KSPActionParam param)
        {
            ToggleMode();
        }

        public override void OnAwake()
        {
            base.OnAwake();
            if (!HighLogic.LoadedSceneIsFlight)
                return;
            _defaultCoM = part.CoMOffset;
            SetDescentMode(IsDescentMode);
        }
    }
}
