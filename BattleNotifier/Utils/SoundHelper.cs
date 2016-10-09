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
        private SoundPlayer soundPlayer;

        public void PlayDefaultSound(int defaultSound)
        {
            soundPlayer = new SoundPlayer(IndexToDefaultSound(defaultSound));
            soundPlayer.Play();
        }

        public void PlaySound(string path, int defaultSound = 0)
        {
            try
            {
                if (IsWavSoundPath(path))
                {
                    PlayWavSound(path);
                }
                else
                {
                    PlayMediaPlayerSound(path);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(201, ex);
                PlayDefaultSound(defaultSound);
            }
        }

        public void StopSound()
        {
            try
            {
                if (soundPlayer != null)
                    soundPlayer.Stop();
                if (mediaPlayer != null)
                    mediaPlayer.Stop();
            }
            catch (Exception ex)
            {
                Logger.Log(201, ex);
            }
        }

        private bool IsWavSoundPath(string path)
        {
            return path.EndsWith(".wav");
        }

        private void PlayMediaPlayerSound(string path)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaFailed += (o, args) =>
            {
                Logger.Log(201, new Exception(args.ErrorException.Message));
            };
            mediaPlayer.Open(new Uri(path, UriKind.Absolute));
            mediaPlayer.Play();
        }

        private void PlayWavSound(string path)
        {
            soundPlayer = new SoundPlayer(path);
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
