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
pub mod Build {
    use super::*;
    use fable_library_rust::Native_::MutArray;
    use fable_library_rust::Native_::on_startup;
    use tauri_build::*;
    on_startup!(());
    pub fn main(_args: Lrc<MutArray<Lrc<str>>>) -> i32 {
        tauri_build::build();
        0i32
    }
}
#[path = "./src/main.rs"]
mod module_e43b409d;
pub fn main() {
    let args: Vec<String> = std::env::args().collect();
    let args: Vec<Lrc<str>> = args[1..].iter().map(|s| string(s)).collect();
    Build::main(array(args));
}
