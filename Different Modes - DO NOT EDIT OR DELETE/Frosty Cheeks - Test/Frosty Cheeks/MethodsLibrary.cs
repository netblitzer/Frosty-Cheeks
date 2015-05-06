#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Frosty_Cheeks
{
    static class MethodsLibrary
    {
        #region Draw Assistants
        public void Draw()
        {

        }
        #endregion
        #region Clamps
        /// <summary>
        /// A basic integer clamp, keeps the value within the specified range.
        /// </summary>
        /// <param name="val">The value to clamp.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The clamped integer.</returns>
        public int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }
        /// <summary>
        /// A basic double clamp, keeps the value within the specified range.
        /// </summary>
        /// <param name="val">The value to clamp.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The clamped double.</returns>
        public double Clamp(double val, double min, double max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }
        /// <summary>
        /// A basic float clamp, keeps the value within the specified range.
        /// </summary>
        /// <param name="val">The value to clamp.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The clamped float.</returns>
        public float Clamp(float val, float min, float max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }
        /// <summary>
        /// A basic Vector2 clamp, keeps the value within the specified range on both x and y.
        /// </summary>
        /// <param name="val">The Vector2 to clamp.</param>
        /// <param name="min">The minimum of the range, on x and y.</param>
        /// <param name="max">The maximum of the range, on x and y.</param>
        /// <returns>The clamped Vector2 between the two vector2s passed in.</returns>
        public Vector2 Clamp(Vector2 val, Vector2 min, Vector2 max)
        {
            // The result that will eventually be returned after the clamp
            Vector2 result = new Vector2();

            // The X portion of the clamp
            if (val.X < min.X)
                result.X = min.X;
            else if (val.X > max.X)
                result.X = max.X;
            else
                result.X = val.X;

            // The Y portion of the clamp
            if (val.Y < min.Y)
                result.Y = min.Y;
            else if (val.Y > max.Y)
                result.Y = max.Y;
            else
                result.Y = val.Y;

            // Returning the result
            return result;
        }
        #endregion
        #region InRange Checks
        /// <summary>
        /// Check to see if a Vector2 is within a range (inclusive).
        /// </summary>
        /// <param name="val">The Vector2 to check.</param>
        /// <param name="min">The minimum of the range, on x and y.</param>
        /// <param name="max">The maximum of the range, on x and y.</param>
        /// <returns>The boolean result of the check.</returns>
        public bool InRange(Vector2 val, Vector2 min, Vector2 max)
        {
            // The result that will eventually be returned
            bool result = true; // Default to true

            // Check the value to see if it's not in the range on the X
            if (val.X < min.X || val.X > max.X)
                result = false;

            // Check the value to see if it's not in the range on the Y
            if (val.Y < min.Y || val.Y > max.Y)
                result = false;

            // Return the result
            return result;
        }
        /// <summary>
        /// Check to see if a integer is within a range (inclusive).
        /// </summary>
        /// <param name="val">The integer to check.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The boolean result of the check.</returns>
        public bool InRange(int val, int min, int max)
        {
            // The result that will eventually be returned
            bool result = true; // Default to true

            // Check the value to see if it's not in the range of the two ints
            if (val < min || val > max)
                result = false;

            // Return the result
            return result;
        }
        /// <summary>
        /// Check to see if a double is within a range (inclusive).
        /// </summary>
        /// <param name="val">The double to check.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The boolean result of the check.</returns>
        public bool InRange(double val, double min, double max)
        {
            // The result that will eventually be returned
            bool result = true; // Default to true

            // Check the value to see if it's not in the range of the two ints
            if (val < min || val > max)
                result = false;

            // Return the result
            return result;
        }
        /// <summary>
        /// Check to see if a float is within a range (inclusive).
        /// </summary>
        /// <param name="val">The float to check.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The boolean result of the check.</returns>
        public bool InRange(float val, float min, float max)
        {
            // The result that will eventually be returned
            bool result = true; // Default to true

            // Check the value to see if it's not in the range of the two ints
            if (val < min || val > max)
                result = false;

            // Return the result
            return result;
        }
        #endregion
    }
}
