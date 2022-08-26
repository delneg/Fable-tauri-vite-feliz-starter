#![allow(dead_code)]
#![allow(non_snake_case)]
#![allow(non_camel_case_types)]
#![allow(non_upper_case_globals)]
#![allow(unused_parens)]
#![allow(unused_imports)]
#![allow(unused_variables)]
#![allow(unused_attributes)]
use fable_library_rust::Native_::Lrc;
use fable_library_rust::Native_::array;
use fable_library_rust::String_::string;
pub mod Main {
    use super::*;
    use fable_library_rust::Native_::MutArray;
    #[derive(Clone, Debug, PartialEq, PartialOrd, Hash, Eq, Ord)]
    pub struct Name {
        pub name: Lrc<str>,
    }
    #[tauri::command]
    pub fn greet(n: &Lrc<Main::Name>) -> Lrc<str> {
        string(&format!("Hello, {0}! You\'ve been greeted from Rust!",
                        &n.name))
    }
    #[tauri::command]
    pub fn add(arg1: i32, arg2: i32) -> i32 { arg1 + arg2 }
    pub fn main(_arg: Lrc<MutArray<Lrc<str>>>) -> i32 {
        tauri::Builder::default().invoke_handler(tauri::generate_handler![greet,add]).run(tauri::generate_context!()).expect("error while running tauri application");;
        0i32
    }
}
pub fn main() {
    let args: Vec<String> = std::env::args().collect();
    let args: Vec<Lrc<str>> = args[1..].iter().map(|s| string(s)).collect();
    Main::main(array(args));
}
