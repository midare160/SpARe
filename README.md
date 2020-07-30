# SpARe
= **Sp**otify **A**d **Re**mover

This software removes/blocks all ads (audio, visual banners) from Spotify Desktop. ***Downloading songs is still not possible without premium!***

It is recommended to install/downgrade Spotify with the included installer. Otherwise I can't guarantee that all ads will be blocked.

# Features

### Start

- Installs/Downgrades Spotify Desktop to version 1.0.80.474
- Deletes the `ad.spa` file, usually located at `C:\Users\<Username>\AppData\Roaming\Spotify\Apps`, that could contain ad data from previous Spotify installations
- Denies access to all users for the *Update* directory of Spotify, usually located at `C:\Users\<Username>\AppData\Local\Spotify\Update`, 
so that Spotify can't update itself to a higher version
- Blocks all Spotify ad servers by writing following lines to the Windows `hosts` file, usually located at `C:\Windows\System32\drivers\etc\hosts`:

```
0.0.0.0 adclick.g.doublecklick.net
0.0.0.0 googleads.g.doubleclick.net
0.0.0.0 googleadservices.com
0.0.0.0 pubads.g.doubleclick.net
0.0.0.0 securepubads.g.doubleclick.net
0.0.0.0 pagead2.googlesyndication.com
0.0.0.0 spclient.wg.spotify.com
0.0.0.0 audio2.spotify.com
```

If the `hosts` file is already containing all of these lines, nothing is written to it.

### Revert

When ads are already removed, you can of course revert the changes made above.

Pressing the *Revert* button will...
- remove Spotify ad servers from `hosts` file
- grant access to *Update* directory again
