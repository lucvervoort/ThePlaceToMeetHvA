import "./App.css";
import RootNavigator from "./navigation/RootNavigator";
import NavBar from "./components/NavBar";

function App() {
  return (
    <div className="py-4 px-8 flex flex-col min-h-screen">
      <NavBar/>
      <RootNavigator />
    </div>
  );
}

export default App;
