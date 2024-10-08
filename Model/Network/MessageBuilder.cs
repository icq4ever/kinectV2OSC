﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Rug.Osc;

namespace KinectV2OSC.Model.Network
{
    public class MessageBuilder
    {
        public OscMessage BuildIDMessage(int kID, Body body)
        {
            var address = String.Format("/bodies/{0}/kinectID", body.TrackingId);
            var id = kID;
            return new OscMessage(address, id);
        }
        public OscMessage BuildJointMessage(Body body, KeyValuePair<JointType, Joint> joint)
        {
            var address = String.Format("/bodies/{0}/joints/{1}", body.TrackingId, joint.Key);
            var position = joint.Value.Position;
            Int32 Key = (Int32)joint.Key;
            // System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address,Key, (Int32)joint.Value.TrackingState);
        }

        public OscMessage buildRootJointMessage(Body body)
        {
            var address = String.Format("/bodies/{0}/jointRoot", body.TrackingId);
            var position = body.Joints[0].Position;
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, position.X, position.Y, position.Z);
        }

        public OscMessage buildOrientMessage(Body body, KeyValuePair<JointType, JointOrientation> joint)
        {
            var address = String.Format("/bodies/{0}/jointorient/{1}", body.TrackingId, joint.Key);
            var orientation = joint.Value.Orientation;
            Int32 Key = (Int32)joint.Key;
            System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, Key,orientation.X, orientation.Y, orientation.Z,orientation.W);
        }

        public OscMessage BuildHandMessage(Body body, string key, HandState state, TrackingConfidence confidence)
        {
            var address = String.Format("/bodies/{0}/hands/{1}", body.TrackingId, key);
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, state.ToString(), confidence.ToString());
        }
    }
}
