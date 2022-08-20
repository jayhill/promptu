﻿//-----------------------------------------------------------------------
// <copyright file="ArgumentSubstitution.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.Itl.AbstractSyntaxTree
{
    internal abstract class ArgumentSubstitution : Expression
    {
        private int? argumentNumber;
        private int? lastArgumentNumber;
        private bool singularSubstitution;

        public ArgumentSubstitution(int? argumentNumber, int? lastArgumentNumber, bool singularSubstitution)
        {
            this.argumentNumber = argumentNumber;
            this.lastArgumentNumber = lastArgumentNumber;
            this.singularSubstitution = singularSubstitution;
        }

        public int? ArgumentNumber
        {
            get { return this.argumentNumber; }
        }

        public int? LastArgumentNumber
        {
            get { return this.lastArgumentNumber; }
        }

        public bool SingularSubstitution
        {
            get { return this.singularSubstitution; }
        }
    }
}
