using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LsonLib;
using System.IO;



namespace PeachFox
{
    public class TileGraphic
    {
        public string File
        {
            get => _root["File"].GetString();
            set => _root["File"] = value;
        }
        public Quad Quad
        {
            get => (Quad)_root["Quad"];
            set => _root["Quad"] = (LsonDict)value;
        }

        public Animation Animation
        {
            set => _root["Animation"] = (LsonDict)value;
        }

        private LsonDict _root;
        public static explicit operator LsonDict(TileGraphic value)
        {
            return value._root;
        }
        public static explicit operator TileGraphic(LsonDict value)
        {
            return new TileGraphic(value);
        }
        public TileGraphic()
        {
            _root = new LsonDict();
            File = "";
            Quad = _root.AddIfNotExist("Quad", x => new Quad(x));
            if (_root.ContainsKey("Animation") == false)
                _root.Add("Animation", null);
        }
        public TileGraphic(string file, Quad quad, Animation animation)
        {
            _root = new LsonDict();
            File = file;
            Quad = quad;
            Animation = animation;
        }
        public TileGraphic(LsonDict root)
        {
            _root = root;
            _root.AddIfNotExist("File", new LsonString(""));
            Quad = _root.AddIfNotExist("Quad", x => new Quad(x));
            if (_root.ContainsKey("Animation") == false)
                _root.Add("Animation", null);
        }
    }

    public static class LsonAddOn
    {
        public static void AddIfNotExist(this LsonDict dict, string key, LsonValue value)
        {
            if (dict.ContainsKey(key) == false)
                dict.Add(key, value);
        }
        public static T AddIfNotExist<T>(this LsonDict dict, string key, Func<LsonDict, T> con)
        {
            if (dict.ContainsKey(key) == false)
                dict.Add(key, new LsonDict());
            return con(dict[key].GetDict());
        }

        public static void Set(this LsonDict dict, int key, TileGraphic value)
        {
            if (dict.ContainsKey(key))
                dict[key] = (LsonDict)value;
            else
                dict.Add(key, (LsonDict)value);
        }
    }
    public class GraphicsData
    {
        public int Width
        {
            get => _root["Width"].GetInt();
            set => _root["Width"] = value;
        }
        public int Height
        {
            get => _root["Height"].GetInt();
            set => _root["Height"] = value;
        }
        public int Scale
        {
            get => _root["Scale"].GetInt();
            set => _root["Scale"] = value;
        }

        private LsonDict _root;
        public static explicit operator LsonDict(GraphicsData value)
        {
            return value._root;
        }
        public static explicit operator GraphicsData(LsonDict value)
        {
            return new GraphicsData(value);
        }
        public GraphicsData()
        {
            _root = new LsonDict();
            Width = 0;
            Height = 0;
            Scale = 1;
        }
        public GraphicsData(int width, int height, int scale)
        {
            _root = new LsonDict();
            Width = width;
            Height = height;
            Scale = scale;
        }
        public GraphicsData(LsonDict root)
        {
            _root = root;
            _root.AddIfNotExist("Width", new LsonNumber(0));
            _root.AddIfNotExist("Height", new LsonNumber(0));
            _root.AddIfNotExist("Scale", new LsonNumber(1));
        }

    }
    public class Animation
    {
        public int X
        {
            get => _root["X"].GetInt();
            set => _root["X"] = value;
        }
        public int Y
        {
            get => _root["Y"].GetInt();
            set => _root["Y"] = value;
        }
        public int Num
        {
            get => _root["Num"].GetInt();
            set => _root["Num"] = value;
        }

        private LsonDict _root;
        public static explicit operator LsonDict(Animation value)
        {
            return value._root;
        }
        public static explicit operator Animation(LsonDict value)
        {
            return new Animation(value);
        }
        public Animation()
        {
            _root = new LsonDict();
            X = 0;
            Y = 0;
            Num = 0;
        }
        public Animation(int x, int y, int num)
        {
            _root = new LsonDict();
            X = x;
            Y = y;
            Num = num;
        }
        public Animation(LsonDict root)
        {
            _root = root;
            _root.AddIfNotExist("X", new LsonNumber(0));
            _root.AddIfNotExist("Y", new LsonNumber(0));
            _root.AddIfNotExist("Num", new LsonNumber(0));
        }
    }
    public class Quad
    {
        public int X
        {
            get => _root["X"].GetInt();
            set => _root["X"] = value;
        }
        public int Y
        {
            get => _root["Y"].GetInt();
            set => _root["Y"] = value;
        }
        public int Width
        {
            get => _root["W"].GetInt();
            set => _root["W"] = value;
        }
        public int Height
        {
            get => _root["H"].GetInt();
            set => _root["H"] = value;
        }

        private LsonDict _root;
        public static explicit operator LsonDict(Quad value)
        {
            return value._root;
        }
        public static explicit operator Quad(LsonDict value)
        {
            return new Quad(value);
        }
        public Quad()
        {
            _root = new LsonDict();
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }

        public Quad(int x, int y, int width, int height)
        {
            _root = new LsonDict();
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Quad(LsonDict root)
        {
            _root = root;
            _root.AddIfNotExist("X", new LsonNumber(0));
            _root.AddIfNotExist("Y", new LsonNumber(0));
            _root.AddIfNotExist("W", new LsonNumber(0));
            _root.AddIfNotExist("H", new LsonNumber(0));
        }
    }
    public class Physics
    {
        public bool Colliable
        {
            get => _root["Colliable"].GetBool();
            set => _root["Colliable"] = value;
        }

        private LsonDict _root;
        public static explicit operator LsonDict(Physics value)
        {
            return value._root;
        }
        public static explicit operator Physics(LsonDict value)
        {
            return new Physics(value);
        }
        public Physics()
        {
            _root = new LsonDict();
            Colliable = false;
        }

        public Physics(bool colliable)
        {
            _root = new LsonDict();
            Colliable = colliable;
        }

        public Physics(LsonDict root)
        {
            _root = root;
            _root.AddIfNotExist("Colliable", new LsonBool(false));
        }
    }
    public class Tile
    {
        public LsonDict Background
        {
            get => _root["Bg"].GetDict();
            set
            {
                _root["Bg"] = value;
            }
        }
        public LsonDict Foreground
        {
            get => _root["Fg"].GetDict();
            set
            {
                _root["Fg"] = value;
            }
        }
        public Physics Physics
        {
            get => (Physics)_root["Physics"];
            set => _root["Physics"] = (LsonDict)value;
    }

        private LsonDict _root;
        public static explicit operator LsonDict(Tile value)
        {
            return value._root;
        }
        public static explicit operator Tile(LsonDict value)
        {
            return new Tile(value);
        }

        public Tile()
        {
            _root = new LsonDict();
            Background = _root.AddIfNotExist("Bg", x => new LsonDict(x));
            Foreground = _root.AddIfNotExist("Fg", x => new LsonDict(x));
            Physics = _root.AddIfNotExist("Physics", x => new Physics(x));
        }
        public Tile(LsonDict background, LsonDict foreground, Physics physics)
        {
            _root = new LsonDict();
            Background = background;
            Foreground = foreground;
            Physics = physics;
        }
        public Tile(LsonDict root)
        {
            _root = root;
            Background = _root.AddIfNotExist("Bg", x => new LsonDict(x));
            Foreground = _root.AddIfNotExist("Fg", x => new LsonDict(x));
            Physics = _root.AddIfNotExist("Physics", x => new Physics(x));
        }
    }
    public class TileMap
    {
        private readonly string _filepath;
        private Dictionary<string, LsonValue> _tileMapRoot;
        private string _activeMap;
        public string ActiveMap
        {
            get => _activeMap;
        }

        public List<string> MapNames { get; }
        public GraphicsData GraphicsData
        {
            get => (GraphicsData)_tileMapRoot[ActiveMap]["Graphics"];
            set => _tileMapRoot[ActiveMap]["Graphics"] = (LsonDict)value;
        }
        public Dictionary<int, Dictionary<int, Tile>> Map
        {
            get
            {
                Dictionary<int, Dictionary<int, Tile>> tiles = new Dictionary<int, Dictionary<int, Tile>>();
                foreach (var i in _tileMapRoot[_activeMap]["Map"].GetDict())
                {
                    tiles[i.Key.GetInt()] = new Dictionary<int, Tile>();
                    foreach (var j in i.Value.GetDict())
                    {
                        tiles[i.Key.GetInt()][j.Key.GetInt()] = (Tile)j.Value.GetDict();
                    }
                }
                return tiles;
            }
            set
            {
                foreach (var i in value)
                {
                    if (_tileMapRoot[_activeMap]["Map"].ContainsKey(i.Key) == false)
                        _tileMapRoot[_activeMap]["Map"].Add(i.Key, new LsonDict());
                    foreach (var j in value[i.Key])
                    {
                        if (_tileMapRoot[_activeMap]["Map"][i.Key].ContainsKey(j.Key) == false)
                            _tileMapRoot[_activeMap]["Map"][i.Key].Add(j.Key, (LsonValue)value[i.Key][j.Key]);
                        else
                            _tileMapRoot[_activeMap]["Map"][i.Key][j.Key] = (LsonValue)value[i.Key][j.Key];
                    }
                }
            }
        }

        public TileMap(string path)
        {
            _filepath = path;
            _tileMapRoot = LsonVars.Parse(File.ReadAllText(_filepath));

            MapNames = new List<string>();
            foreach (var map in _tileMapRoot)
                MapNames.Add(map.Key);
            _activeMap = MapNames.Count > 0 ? MapNames[0] : "";
        }

        public void NewMap(string name)
        {
            throw new NotImplementedException();
            //MapNames.Add(name);
            // _tileMapRoot.add(...);
        }

        public void SelectMap(string name)
        {
            var result = MapNames.FindIndex(x => x == name);
            if (result == -1)
                throw new IndexOutOfRangeException(name + " does not exist in map");
            _activeMap = name;
        }
        
        public bool RenameMap(string oldName, string newName)
        {
            if (_tileMapRoot.TryGetValue(oldName, out LsonValue value))
                return false;

            _tileMapRoot.Remove(oldName);
            _tileMapRoot[newName] = value;

            MapNames.Remove(oldName);
            MapNames.Add(newName);
            if (ActiveMap == oldName)
                _activeMap = newName;

            return true;
        }

        public string String()
        {
            return LsonVars.ToString(_tileMapRoot);
        }
    }
}
