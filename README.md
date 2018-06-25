# FolderInfo
Basic folder size info stastics console program.
User enters absolute or relative directory to scan, program computes size statistics and prints results in console or tree view form.
If user hits only enter without input directory, program scans application directory.

### Usage
Run the program, in console enter relative or absolute folder path to scan. If the folder path is empty, programs scans application directory. Hit enter, program will scan folder and print results in console if directory exists. Users can run the program with two optional command line arguments - see [Optional command line arguments](https://github.com/grekkster/FolderInfo/new/master?readme=1#folder-information-output)

### Optional command line arguments
`alldirs` - shows statistics for entered folder and all subdirectories

`showtree` - shows the results also in popup tree view form

### Folder information output
**Folder** - Folder directory

**Size** - Folder size including subdirectories

**Size Without SubFolders** - Folder size without subfolders (only files in folder)

**Folder Count** - Folder count including parent and subdirectories

**Min Folder Size** - Minimal folder size in a folder tree

**Max Folder Size** - Maximal folder size in a folder tree

**Average Folder Size** - Average folder size in a folder tree
