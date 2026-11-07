using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShambersMicroServicesMultiSoft.Support
{
    internal class SoundFunctions
    {
        public void PlayOn(string SoundPath)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(SoundPath);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void PlayOff()
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void AttentionPlay(string soundPaths, string status)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(soundPaths);
                while (status == "attention")
                {
                    soundPlayer.Play();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
