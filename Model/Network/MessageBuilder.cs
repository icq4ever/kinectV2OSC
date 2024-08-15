using System;
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
        public OscMessage BuildJointMessage(int kID, Body body, KeyValuePair<JointType, Joint> joint)
        {
            var address = String.Format("/{0}/bodies/{1}/joints/{2}", kID, body.TrackingId, joint.Key);
            var position = joint.Value.Position;
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, position.X, position.Y, position.Z, joint.Value.TrackingState.ToString());
        }

        public OscMessage BuildHandMessage(int kID, Body body, string key, HandState state, TrackingConfidence confidence)
        {
            var address = String.Format("/{0}/bodies/{1}/hands/{2}", kID, body.TrackingId, key);
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, state.ToString(), confidence.ToString());
        }
    }
}
