# G-Helper (with remapped keys)

### 🤔 Why did I make this?
I had recently broken the spacebar on my keyboard and around the same time I discovered that some Zephyrus G14 models had a different layouts for the function keys. Since I was going to order and replace my keyboard anyways, it was the perfect opportunity to order a new keyboard with the layout that I preferred. I though the drivers would automatically adjust to the new function key layout but that was not the case so I coded it myself.

|Old Layout|New Layout|
|---|---|
|<img src="https://i.ibb.co/zQjyVQm/5177-Hn-Ssz-L-AC-SL1500.jpg" alt="old"/>|<img src="https://i.postimg.cc/nVWRyFb6/61ro-Q15-Vn-NL-AC-UF894-1000-QL80-1.jpg" alt="new"/>|

### ⌨️ Remapped Keys

|Key|Old|New|
|---|---|---|
|`Fn + F2`|Keyboard Backlight Down|Previous Track|
|`Fn + F3`|Keyboard Backlight Up|Play/Pause|
|`Fn + F4`|Aura|Next track|
|`Fn + Arrow Up`|Page Up|Keyboard Backlight Up|
|`Fn + Arrow Down`|Page Down|Keyboard Backlight Down|

### 🪰 Known Bugs
- Window flashes when appearing
- There is a `System.InvalidOperationException` when quitting the program
   - This does not have any side effects and can safely be ignored (click "Quit" again in the error window)
 
### 🏗️ How to install

#### Requirements
- [Microsoft .NET 7](https://download.visualstudio.microsoft.com/download/pr/03a5170a-a4cd-458c-b5d0-e5149ee4fdcf/e9026f6fe3c3fec4a774e034d4f98ead/dotnet-sdk-7.0.404-win-x64.exe)

#### Install Steps
- Clone repo
- Make sure your current working directory is `g-helper/app`
   - If not run `cd app`
- Run `dotnet build ./GHelper.sln`
- You should now have a folder called `bin` at `g-helper/app/bin`
- Copy everything inside the `g-helper/app/bin/Debug` (x86) or `g-helper/app/bin/x64/Debug` (x64) folder to your preferred install location
- Create a shortcut to `ghelper.exe` and put it in `%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup`
- G-Helper should now run on startup
------------------
### 🔖 Important Notice

#### Projets used
- [G-Helper](https://github.com/seerge/g-helper)

#### Disclaimers
"ROG", "TUF", and "Armoury Crate" are trademarked by and belong to AsusTek Computer, Inc. I make no claims to these or any assets belonging to AsusTek Computer and use them purely for informational purposes only.

THE SOFTWARE IS PROVIDED “AS IS” AND WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. MISUSE OF THIS SOFTWARE COULD CAUSE SYSTEM INSTABILITY OR MALFUNCTION.
