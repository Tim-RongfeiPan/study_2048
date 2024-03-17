# study_2048

study_2048 is used only for self-study. The study materials is: [2048](https://zhuanlan.zhihu.com/p/645656810).

# Tips

There are some tips for unity beginners when replicating this project with the link above.

-   Remember to add all scripts for each object in unity. For example GameManager, and also add scripts for Board, Game Over, Score Text and Hiscore Text.
-   Also remember to add similar content in board object. In the TileStates array, add all your predefined tile state in tiles folder.
-   If you want to add cells under rows manually, you could change the following code:

    > public TileCell[] cells { get; set; }// 当前行所管辖的单元格

    to:

    > public TileCell[] cells; // 当前行所管辖的单元格

    then, you can add cell by yourself.

-   If you want to play your game:

    click $File$ -> $Build Settings$ -> $Build$ -> choose your path -> **$Play!$ :)**

Enjoy your time for game development ~ :laughing:
