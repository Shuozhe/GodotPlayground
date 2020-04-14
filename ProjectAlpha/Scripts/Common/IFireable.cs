using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IFireable
{
  void Fire(float strength, Vector2 globalPos, float rotation, Vector2 direction);
}
