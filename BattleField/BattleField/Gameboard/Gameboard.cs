namespace BattleField.Gameboard
{
    using System;
    using System.Collections.Generic;
    using BattleField.Cells;
    using BattleField.Contracts;
    using BattleField.Controllers;
    using BattleField.Detonation;
    using BattleField.Enumerations;
    using BattleField.Gameboard;
    using BattleField.GameEngine;
    using BattleField.Helpers;

    /// <summary>
    /// Represents the Gameboard with a field.
    /// </summary>
    public class Gameboard : IGameboard
    {        
        private ICell[][] field;
        private int minesCount;
        private int size;
        private IDetonationPatternFactory detonationFactory;

        /// <summary>
        /// Create a gameboard of dimension size.
        /// </summary>
        public Gameboard(int size)
        {
            this.field = new ICell[size][];
            for (int i = 0; i < size; i++)
            {
                this.field[i] = new ICell[size];
            }

            this.Size = size;
        }

        /// <summary>
        /// Gets/Sets the number of mines in field.
        /// </summary>
        public int MinesCount
        {
            get
            {
                return this.minesCount;
            }

            set
            {
                this.minesCount = value;
            }
        }

        /// <summary>
        /// Gets/Sets the size of the field.
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        /// <summary>
        /// Gets/Sets the Gameboard's cell at position.
        /// </summary>
        public ICell this[int x, int y]
        {
            get
            {
                return this.field[x][y];
            }

            set
            {
                this.field[x][y] = value;
            }
        }

        /// <summary>
        /// Set the detonation factory.
        /// </summary>
        public void SetDetonationFactory(IDetonationPatternFactory detonationFactory)
        {
            this.detonationFactory = detonationFactory;
        }

        /// <summary>
        /// Detonate the mine at position 'position'.
        /// </summary>
        public void Detonate(Position position)
        {
            DetonationPattern detonationPattern = this.detonationFactory.GetDetonationPattern(position, this);
            detonationPattern.Detonate(position, this);
        }        
    }
}
