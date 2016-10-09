using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using Utils;

namespace BattleNotifier.Utils
{
    public class SoundHelper
    {
        private MediaPlayer mediaPlayer;

        public void PlaySound(string path, int defaultSound = 0)
        {
            try
            {
                mediaPlayer = new MediaPlayer();
                mediaPlayer.MediaFailed += (o, args) =>
                {
                    Logger.Log(200, new Exception(args.ErrorException.Message));
                };
                mediaPlayer.Open(new Uri(path, UriKind.Absolute));

                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                Logger.Log(200, ex);
                PlayDefaultSound(defaultSound);
            }
        }

        public void StopSound()
        {
            try
            {
                if (mediaPlayer != null)
                    mediaPlayer.Stop();
            }
            catch (Exception ex)
            {
                Logger.Log(201, ex);
            }
        }

        public void PlayDefaultSound(int defaultSound)
        {
            var soundPlayer = new SoundPlayer(IndexToDefaultSound(defaultSound));
            soundPlayer.Play();
        }

        private Stream IndexToDefaultSound(int index)
        {
            switch (index)
            {
                case 0:
                    return Properties.Resources.apple;
                case 1:
                    return Properties.Resources.flower;
                case 2:
                    return Properties.Resources.wroom;
                case 3:
                    return Properties.Resources.deaded;
                case 4:
                    var random = new Random();
                    int randomCase = random.Next(0, 4);
                    return IndexToDefaultSound(randomCase);
                default:
                    return Properties.Resources.apple;
            }
        }
    }
}
