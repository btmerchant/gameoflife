# Conway's Game of Life

## Game Rules
1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
2. Any live cell with two or three live neighbours lives on to the next generation.
3. Any live cell with more than three live neighbours dies, as if by overcrowding.
4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

This Implementation produces a visualization in the console window and has the following Features.

  1. World Grid is adjustable from 10 to 45 (defalts to 45), select "S" when prompted to change.
  2. You can toggle on and off a border around the grid (default is false), select "B" when prompted to toggle.
  3. You can select several standard patterns to load on start, follow prompts.
  4. You can choose to load the grid with a generated fill of Random cells, select "R" when prompted.
  5. Tabulates statistics during, and sumarizes after the game ends.
  6. When all movement has been reduced to "Stills" and "Blinkers" the game Automatically ends.
  7. Cycle directly into another game, or select "Q" to Quit the program.

## References
- http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
- http://mathworld.wolfram.com/GameofLife.html
