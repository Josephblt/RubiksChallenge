﻿
using RubiksChallenge.Geometry;

namespace RubiksChallenge.Entities.CubeStructure.Layers
{
    public class BottomLayer : AbstractLayer
    {
        #region Constructor

        public BottomLayer()
        {
            position[2] = new Point3D(0, 0, 0);
            position[1] = new Point3D(0, 0, 1);
            position[0] = new Point3D(0, 0, 2);
            position[7] = new Point3D(1, 0, 2);
            position[6] = new Point3D(2, 0, 2);
            position[5] = new Point3D(2, 0, 1);
            position[4] = new Point3D(2, 0, 0);
            position[3] = new Point3D(1, 0, 0);

            this.MiddlePosition = new Point3D(1, 0, 1);
        }

        #endregion

        #region Overriden Methods

        protected override void ExecuteRotation(RotationDirection rotationDirection)
        {
            var rf = rotationFactor;
            if (rotationDirection == RotationDirection.Positive
                )
                rf *= -1;

            for (int i = 0; i < 9; i++)
            {
                Cube rotationCube;

                if (i == 8)
                    rotationCube = this.GetCube(this.MiddlePosition);
                else
                    rotationCube = this.GetCube(position[i]);

                Vector3D rotationVector = new Vector3D(0.0f, 1.0f, 0.0f);
                rotationCube.Position.RotateAndTranslate(rotationVector, rf);
            }
        }

        #endregion
    }
}
