/*
 * IoT Edge Management API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2018-06-28
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

use serde_derive::{Deserialize, Serialize};
#[allow(unused_imports)]
use serde_json::Value;

#[derive(Debug, Serialize, Deserialize)]
pub struct Identity {
    #[serde(rename = "moduleId")]
    module_id: String,
    #[serde(rename = "managedBy")]
    managed_by: String,
    #[serde(rename = "generationId")]
    generation_id: String,
    #[serde(rename = "authType")]
    auth_type: String,
}

impl Identity {
    pub fn new(
        module_id: String,
        managed_by: String,
        generation_id: String,
        auth_type: String,
    ) -> Self {
        Identity {
            module_id,
            managed_by,
            generation_id,
            auth_type,
        }
    }

    pub fn set_module_id(&mut self, module_id: String) {
        self.module_id = module_id;
    }

    pub fn with_module_id(mut self, module_id: String) -> Self {
        self.module_id = module_id;
        self
    }

    pub fn module_id(&self) -> &String {
        &self.module_id
    }

    pub fn set_managed_by(&mut self, managed_by: String) {
        self.managed_by = managed_by;
    }

    pub fn with_managed_by(mut self, managed_by: String) -> Self {
        self.managed_by = managed_by;
        self
    }

    pub fn managed_by(&self) -> &String {
        &self.managed_by
    }

    pub fn set_generation_id(&mut self, generation_id: String) {
        self.generation_id = generation_id;
    }

    pub fn with_generation_id(mut self, generation_id: String) -> Self {
        self.generation_id = generation_id;
        self
    }

    pub fn generation_id(&self) -> &String {
        &self.generation_id
    }

    pub fn set_auth_type(&mut self, auth_type: String) {
        self.auth_type = auth_type;
    }

    pub fn with_auth_type(mut self, auth_type: String) -> Self {
        self.auth_type = auth_type;
        self
    }

    pub fn auth_type(&self) -> &String {
        &self.auth_type
    }
}
