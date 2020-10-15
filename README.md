# fmod-testing
*Improving the FMOD / Git / Unity workflow.*
---
Stuff that has worked well so far:
1. Updating gitignore with
  ```
  # FMOD related files
  Assets/Plugins/FMOD/Cache/
  Assets/StreamingAssets/**/*.bank
  Assets/StreamingAssets/**/*.bank.meta
  fmod_editor.log
  ```
2. Targeting a parent "FMOD" folder outside of unity home directory with FMOD banks and assets

**TODO: Find a way to share actual FMOD project files for audio team collaboration**
  - maybe store it as a git submodule?
  - test out best practices for audio collaboration: e.g. seperating all work into folders
    and later merging into master folders for release
