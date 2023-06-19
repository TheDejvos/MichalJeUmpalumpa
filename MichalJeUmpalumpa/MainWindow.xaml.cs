using System;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace MichalJeUmpalumpa;

public partial class MainWindow{
    private static string[] vids = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Videos")).Select(x => x.Split('\\').Last()).ToArray();

    private bool playbackState;
    private int playbackVid;

    public MainWindow(){
        InitializeComponent();

        DetailsLabel.Text = vids[playbackVid];
        Player.Source = new Uri($"./Videos/{vids[playbackVid]}", UriKind.Relative);
        Player.Play();
    }

    private void PrevClick(object sender, MouseButtonEventArgs e) {
        playbackVid--;
        if(playbackVid < 0){
            playbackVid = vids.Length - 1;
        }

        PlaybackStateLabel.Content = "Pause";
        DetailsLabel.Text = vids[playbackVid];

        Player.Source = new Uri($"./Videos/{vids[playbackVid]}", UriKind.Relative);
        Player.Play();
    }

    private void PlaybackClick(object sender, MouseButtonEventArgs e){
        playbackState = !playbackState;
        PlaybackStateLabel.Content = playbackState ? "Play" : "Pause";

        if(playbackState){
            Player.Pause();
        }else{
            Player.Play();
        }
    }

    private void NextClick(object sender, MouseButtonEventArgs e){
        playbackVid++;
        if(playbackVid > vids.Length - 1){
            playbackVid = 0;
        }

        PlaybackStateLabel.Content = "Pause";
        DetailsLabel.Text = vids[playbackVid];

        Player.Source = new Uri($"./Videos/{vids[playbackVid]}", UriKind.Relative);
        Player.Play();
    }
}